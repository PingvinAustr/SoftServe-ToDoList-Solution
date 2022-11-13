import React from 'react';
import '../css/TaskWindow.css';
import '../css/Sidebar.css';
import Sidebar from "./Sidebar";
import { Layout } from 'antd';
import {Button, Col, Row, Typography, Space } from 'antd';
import {NotificationOutlined} from "@ant-design/icons"
import {getCategoryNamePerId, getItemNamePerId} from "../js/functions";
import ConfirmationModal from "./ConfirmationModal";
import EditModal, {EditTask} from "./EditModal";
import FormModal, {AddTask} from "./FormModal";
import {tab} from "@testing-library/user-event/dist/tab";
import * as $ from "jquery";
const { Header, Footer, Sider, Content } = Layout;

interface TasksTableProps {
    categoryId: number,
}

interface Task{
    taskId:number,
    taskName:string,
    taskDescription:string,
    taskUrgency:number,
    taskCategory:number,
    taskStatus:number
}

function TasksTable(props:TasksTableProps) {
    getTasksPerCategoryId(props.categoryId);
    let selectedCategoryName:string;
    const [tableItems, updateTableItems] = React.useState(itemListResponse);

    selectedCategoryName=getCategoryNamePerId(props.categoryId);



    const listItems=tableItems.map(row=>
        <Row>
            <Col className={"grid_col_item"} span={5}>{row.taskName}</Col>
            <Col className={"grid_col_item"} span={6}>{row.taskDescription}</Col>
            <Col className={"grid_col_item"} span={5}>{getItemNamePerId("urgency", row.taskUrgency)}</Col>
            <Col className={"grid_col_item"} span={5}>{getItemNamePerId("status",row.taskStatus)}</Col>
            <Col className={"grid_col_item"} span={3}>
                <Space>
                    <ConfirmationModal modalTitle={"Delete"} modalContent={"Do you really want to delete this task?"} modalOkText={"Yes"} modalCancelText={"NO"} doSomething={()=>{deleteTaskPerId(row.taskId); getTasksPerCategoryId(props.categoryId); updateTableItems(itemListResponse)}} />
                    <EditModal type={"taskEdit"} doSomething={()=>{EditTask(row.taskId); getTasksPerCategoryId(props.categoryId); updateTableItems(itemListResponse)}}/>
                </Space>
            </Col>
        </Row>);
    return (
        <div className={"popupHead"}>
        <Row style={{fontSize:"24px"}}>
            <Col span={15}>
                <div id="currentCategoryNameDiv" style={{wordBreak:"break-all", lineHeight:"1"}}>{selectedCategoryName}</div>
            </Col>
            <Col span={3} offset={6}>
                <FormModal doSomething={()=>{AddTask(); getTasksPerCategoryId(props.categoryId); updateTableItems(itemListResponse)}}/>
            </Col>
        </Row>
        <div id={"tableRender"} style={{height:"65vh",overflowY:"auto", marginTop:"10px"}}>
            <Row id={"tableHeaderRow"} style={{marginLeft:"1px", minHeight:"50px"}} >
                <Col className={"grid_col_item"} span={5}>Task Name:</Col>
                <Col className={"grid_col_item"} span={6}>Task Description:</Col>
                <Col className={"grid_col_item"} span={5}>Task Urgency:</Col>
                <Col className={"grid_col_item"} span={5}>Task Status:</Col>
                <Col className={"grid_col_item"} span={3}>Actions:</Col>
            </Row>
            <div>
        {listItems}
        </div>
        </div>
        </div>
    );

    function deleteTaskPerId(taskId:number){
        console.log("Deletion of task with id:"+taskId);

        $.ajax({
            type: 'DELETE',
            url: 'https://localhost:7025/api/Task_/id?='+taskId,
            async: false,
            data:{
                id:taskId
            },
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            success: function (response) {
                console.log(response);
            },
            error: function (response, status, error) {
                console.log(JSON.stringify(response));
            }
        });


    }

}

export default TasksTable;


var itemListResponse:Item[]=[];



interface Item {
    taskId: number
    taskName: string
    taskDescription: string
    taskUrgency:number
    taskCategory:number
    taskStatus:number
    taskCategoryNavigation:object
    taskStatusNavigation:object
    taskUrgencyNavigation:object

}

function getTasksPerCategoryId(id:number){

    $.ajax({
        method: 'GET',
        url: 'https://localhost:7025/api/Task_/'+id,
        data: {
            category_id:id
        },
        async: false,
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        success: function (response) {
            console.log("Recieved all tasks from ["+id+"] category");
            console.log(JSON.stringify(response));

            itemListResponse=response;
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
}