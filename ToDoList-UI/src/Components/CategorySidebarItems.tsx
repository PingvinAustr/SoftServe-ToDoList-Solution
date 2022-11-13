import React, { useState } from 'react';
import '../css/Sidebar.css';
import * as $ from 'jquery';
import ReactDOM from "react-dom/client";
import {Button, Layout, Col, Row, Typography, Space } from 'antd';
import FormModal from "./FormModal";
import EditModal, {EditTask, EditCategory} from "./EditModal";
import currentOpenedCategory from "../js/currentOpenedCategory";
import {getItemNamePerId, deleteTaskPerId, deleteCategoryPerId} from "../js/functions";
import ConfirmationModal from "./ConfirmationModal";
import {AddTask} from "./FormModal";
import TasksTable from "./TasksTable";
import {EditOutlined} from '@ant-design/icons';

const { Paragraph } = Typography;
const { Header, Footer, Sider, Content } = Layout;




var renderListNames:string[] = [];
var renderListIds:number[]=[];
var renderTest:string[]=[];
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

getAllCaregories();
interface Category{
    categoryId:number,
    categoryName:string,
    doSomething: Function
}
interface CategoryList{
    categories: Category[];
}
interface FunctionProp{
    action: (params: any) => any;
}
var categoryList:Category[]=[];
/*
function CategorySidebarItems({categories}:CategoryList, action:FunctionProp ) {
    console.log(categories);
    const numbers=renderListNames
    const listItems=categories.map((item)=>
        <div key={item.toString()} id={item.categoryId.toString()}  className="single_category_item" >
            <div onClick={() =>OpenSelectedCategory(item.categoryId)} style={{width:"75%", lineHeight:"1.1"}}>{item.categoryName}</div>
            <div style={{width:"15%", display:"flex"}}>
                <ConfirmationModal modalTitle={"Delete the category"} modalContent={"Do you really want to delete this category?"} modalOkText={"Yes"} modalCancelText={"No"} doSomething={()=>deleteCategoryPerId(item.categoryId)}  />
                <EditModal type={"categoryEdit"} doSomething={()=>EditCategory(item.categoryId)}/>
            </div>
        </div>
    );

    for (let i=0;i<listItems.length;i++){
         console.log(listItems[i]);
    }
    return (
        <div>{listItems}</div>
    );
}


export default CategorySidebarItems;
*/


// ============================ AJAX ===================================
function getAllCaregories() {
    $.ajax({
        method: 'GET',
        url: 'https://localhost:7025/api/Categories',
        // data: null
        async: false,
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        success: function (response) {
            //console.log(JSON.stringify(response));
            for (let i=0;i<response.length;i++){
                renderListNames.push(response[i]['categoryName']);
                renderListIds.push(response[i]['categoryId']);
            }
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
}

/*
export function OpenSelectedCategory(input:number){

    console.log("Opening category with ID:"+input);
    currentOpenedCategory.category_id=input;
    console.log("current opened category="+currentOpenedCategory.category_id);
    const root = ReactDOM.createRoot(document.getElementById('Content1') as HTMLElement);
       root.render(<TasksTable categoryId={input}/>)

 //var item = document.getElementById("Layout1");
 //if (item != null) item.hidden=false;

 //getAllTasksFromCurrentCategory(input);
}
*/
/*
function LoadTasksToSelectedCategory(id:number){
    getItemNamePerId("status",1);
    const listItems=itemListResponse.map((item:Item)=>
            <Row style={{marginLeft:"1px", minHeight:"50px"}}>
                <Col className={"grid_col_item"} span={5}>{item.taskName}</Col>
                <Col className={"grid_col_item"} span={6}>{item.taskDescription}</Col>
                <Col className={"grid_col_item"} span={5}>{getItemNamePerId("urgency", item.taskUrgency)}</Col>
                <Col className={"grid_col_item"} span={5}>{getItemNamePerId("status",item.taskStatus)}</Col>
                <Col className={"grid_col_item"} span={3}>
                    <Space>
                    <ConfirmationModal modalTitle={"Delete"} modalContent={"Do you really want to delete this task?"} modalOkText={"Yes"} modalCancelText={"NO"} doSomething={()=>{deleteTaskPerId(item.taskId); OpenSelectedCategory(currentOpenedCategory.category_id); }} />
                    <EditModal type={"taskEdit"} doSomething={()=>{EditTask(item.taskId); OpenSelectedCategory(currentOpenedCategory.category_id);}}/>
                    </Space>
                </Col>
            </Row>

    );

    // СПРОСИТЬ
    const root = ReactDOM.createRoot(
        document.getElementById('Content1') as HTMLElement
    );




    root.render(
        <div className={"popupHead"}>
            <Row style={{fontSize:"24px"}}>
                <Col span={15}>
                    <div id="currentCategoryNameDiv" style={{wordBreak:"break-all", lineHeight:"1"}}>{renderListNames[renderListIds.findIndex(x=>x==id)!]!}</div>
                </Col>
                <Col span={3} offset={6}>
                    <FormModal doSomething={()=>AddTask()}/>
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
            <div>{listItems}</div>
            </div>
        </div>

    );
}

function getAllTasksFromCurrentCategory(id:number){

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
            LoadTasksToSelectedCategory(id);
            currentOpenedCategory.category_id=id;
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
}

*/