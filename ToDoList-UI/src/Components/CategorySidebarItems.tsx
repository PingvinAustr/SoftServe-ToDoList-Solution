import React, { useState } from 'react';
import '../css/Sidebar.css';
import * as $ from 'jquery';
import ReactDOM from "react-dom/client";
import { Layout } from 'antd';
import { Col, Row } from 'antd';
import FormModal from "./FormModal";
import currentOpenedCategory from "../js/currentOpenedCategory";
import {getItemNamePerId} from "../js/functions";
import { Tooltip } from 'antd';
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


function CategorySidebarItems() {


    const numbers=renderListNames;
    const listItems=numbers.map((number) =>

            <Tooltip title={number} color={"black"} placement={"right"} trigger={"hover"}>
                <div key={number.toString()} id={renderListIds[renderListNames.findIndex(x=>x==number)].toString()}  className="single_category_item" onClick={() =>OpenSelectedCategory(renderListIds[renderListNames.findIndex(x=>x==number)])}>{number}</div>
            </Tooltip>
        );
    for (let i=0;i<listItems.length;i++){
         console.log(listItems[i]);
    }
    return (
        <div>{listItems}</div>
    );
}


export default CategorySidebarItems;

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

export function OpenSelectedCategory(input:number){

    console.log("Opening category with ID:"+input);
 var item = document.getElementById("Layout1");
 if (item != null) item.hidden=false;

 getAllTasksFromCurrentCategory(input);
}

function LoadTasksToSelectedCategory(id:number){
    getItemNamePerId("status",1);
    const listItems=itemListResponse.map((item:Item)=>
            <Row style={{fontSize: "16px",marginLeft:"1px"}}>
                <Col className={"grid_col_item"} span={5}>{item.taskName}</Col>
                <Col className={"grid_col_item"} span={6}>{item.taskDescription}</Col>
                <Col className={"grid_col_item"} span={5}>{getItemNamePerId("urgency", item.taskUrgency)}</Col>
                <Col className={"grid_col_item"} span={5}>{getItemNamePerId("status",item.taskStatus)}</Col>
                <Col className={"grid_col_item"} span={3}>Task Buttons:</Col>
            </Row>

    );

    // СПРОСИТЬ
    const root = ReactDOM.createRoot(
        document.getElementById('Content1') as HTMLElement
    );




    root.render(
        <div className={"popupHead"}>
            <Row style={{fontSize:"24px"}}>
                <Col span={21}>
                    <div id="currentCategoryNameDiv">{renderListNames[renderListIds.findIndex(x=>x==id)!]!}</div>
                </Col>
                <Col span={3}>
                    <FormModal/>
                </Col>
            </Row>
            <div style={{height:"65vh",overflowY:"auto"}}>
            <Row  style={{fontSize:"20px", marginLeft:"1px"}} >
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

