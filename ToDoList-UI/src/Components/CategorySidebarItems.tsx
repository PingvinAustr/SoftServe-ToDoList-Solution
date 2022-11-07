import React from 'react';
import '../css/Sidebar.css';
import * as $ from 'jquery';
import ReactDOM from "react-dom/client";
import { Button, Popconfirm, Space, Upload } from 'antd';
import { Layout } from 'antd';
import { Col, Row } from 'antd';
const { Header, Footer, Sider, Content } = Layout;
var renderListNames:string[] = [];
var renderListIds:number[]=[];
var renderTest:string[]=[];

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
    <div key={number.toString()} id={renderListIds[renderListNames.findIndex(x=>x==number)].toString()}  className="single_category_item" onClick={() =>OpenSelectedCategory(renderListIds[renderListNames.findIndex(x=>x==number)])}>{number}</div>
    );
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

function OpenSelectedCategory(input:number){

    console.log("Opening category with ID:"+input);
 var item = document.getElementById("Layout1");
 if (item != null) item.hidden=false;

 getAllTasksFromCurrentCategory(input);
}

function LoadTasksToSelectedCategory(){

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
            var itemListResponse:Item[]=[];
            itemListResponse=response;
            const listItems=itemListResponse.map((item:Item)=>
            <Row>{item.taskName}</Row>
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
                            <Button size={"large"} type="primary">Add task</Button>
                        </Col>
                    </Row>
                <div>{listItems}</div>
                </div>

            );

        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
}