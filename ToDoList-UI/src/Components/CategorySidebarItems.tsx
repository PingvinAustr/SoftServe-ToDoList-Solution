import React from 'react';
import '../css/Sidebar.css';
import * as $ from 'jquery';
var renderListNames:string[] = [];
var renderListIds:number[]=[];

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
 var item = document.getElementById("taskWindow");
 if (item != null) item.style.display="block";

 var text = document.getElementById("currentCategoryNameDiv");
 if (text!=null) text.innerHTML=renderListNames[renderListIds.findIndex(x=>x==input)!]!;
}