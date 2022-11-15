import React from 'react';
import '../css/Sidebar.css';
import currentOpenedCategory from "../js/currentOpenedCategory";
import { Input } from 'antd';
import * as $ from "jquery";
import { useState } from 'react';
import {deleteTaskPerId} from "../js/functions";
import ConfirmationModal from "./ConfirmationModal";
import EditModal from "./EditModal";
import {EditCategory} from "./EditModal";
import ReactDOM from "react-dom/client";
import TasksTable from "./TasksTable";
interface Category{
    categoryId:number,
    categoryName:string,
    doSomething: Function
}
var categoryList:Category[]=[];

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

getAllCaregories()
function Sidebar() {
    const [categories, setCategories] = useState(categoryList);

    function onAdd(){
        addCategory();
        getAllCaregories();
        setCategories(categoryList);
    }
    const listItems=categories.map((item)=>
        <div key={item.toString()} id={item.categoryId.toString()}  className="single_category_item" >
            <div id={item.categoryId.toString()} onClick={() => OpenSelectedCategory(item.categoryId)} style={{width:"75%", lineHeight:"1.1"}}>{item.categoryName}</div>
            <div style={{width:"15%", display:"flex"}}>
                <ConfirmationModal modalTitle={"Delete the category"} modalContent={"Do you really want to delete this category?"} modalOkText={"Yes"} modalCancelText={"No"} doSomething={()=>deleteCategoryPerId(item.categoryId)} />
                <EditModal type={"categoryEdit"} doSomething={()=>{EditCategory(item.categoryId);getAllCaregories();setCategories(categoryList)}}/>
            </div>
        </div>
    );



    function deleteCategoryPerId(categoryId:number){
        console.log("Deletion of task with id:"+categoryId);
        getAllTasksFromCurrentCategory(categoryId);
        for (let i=0; i<itemListResponse.length;i++){
            deleteTaskPerId(itemListResponse[i].taskId);
        }

        $.ajax({
            type: 'DELETE',
            url: 'https://localhost:7025/api/Categories/'+categoryId,
            async: false,
            data:{
                id:categoryId
            },
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            success: function (response) {
                console.log(response);
                getAllCaregories();
                setCategories(categoryList);
            },
            error: function (response, status, error) {
                console.log(JSON.stringify(response));
            }
        });
        var item = document.getElementById("Layout1");
        if (item != null) item.hidden=true;


    }

    return (
        <div className="sidebar_container">

            <Input type={"text"} id={"categoryInput"} placeholder={"Category name"} maxLength={70} showCount={true}></Input>
            <div className="add_button" onClick={onAdd} >Add</div>

            <div>
                {listItems}
            </div>

        </div>
    );
}

export default Sidebar;

function addCategory() {
    let categoryName = (document.getElementById("categoryInput") as HTMLInputElement).value;
    $.ajax({
        method: 'POST',
        url: 'https://localhost:7025/api/Categories',
        data:
            {
                categoryName:categoryName
            },
        async: false,
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));
            return response;
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
    //CategorySidebarItems();



}

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
            categoryList=response;
            //console.log(categoryList);
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
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
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
}

export function OpenSelectedCategory(input:number) {

    console.log("Opening category with ID:" + input);
    currentOpenedCategory.category_id=input;
    var item = document.getElementById("Layout1");
    if (item != null) item.hidden=false;
    const root = ReactDOM.createRoot(document.getElementById('Content1') as HTMLElement);
    root.render(<TasksTable categoryId={input}/>);
}