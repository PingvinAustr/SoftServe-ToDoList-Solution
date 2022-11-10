import React from 'react';
import '../css/Sidebar.css';
import './CategorySidebarItems'
import CategorySidebarItems from "./CategorySidebarItems";
import {OpenSelectedCategory} from "./CategorySidebarItems";
import currentOpenedCategory from "../js/currentOpenedCategory";
import { Input } from 'antd';
import * as $ from "jquery";

function Sidebar() {

    return (
        <div className="sidebar_container">

            <Input type={"text"} id={"categoryInput"} placeholder={"Category name"} maxLength={70} showCount={true}></Input>
            <div className="add_button" onClick={addCategory}>Add</div>
            <CategorySidebarItems/>

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
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
    //CategorySidebarItems();
    document.location.reload();



}

