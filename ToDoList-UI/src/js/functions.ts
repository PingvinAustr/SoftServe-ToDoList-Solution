import * as $ from "jquery";
import {OpenSelectedCategory} from "../Components/CategorySidebarItems";
import currentOpenedCategory from "./currentOpenedCategory";
var urgencyListResponse:Urgency[]=[];
var statusListResponse:Status[]=[];

interface Urgency {
    urgencyId: number
    urgencyName: string
    tasks:[object];
}
interface Status{
    statusId: number
    statusName: string
    tasks:[object];
}



export function getItemNamePerId(item_type:string, item_id:number){
    let found_name:string;
    found_name="";
    switch (item_type){
        case "status": {
            getAllStatuses();
            for (let i=0;i<statusListResponse.length;i++){
                if (item_id==statusListResponse[i].statusId){
                    found_name=statusListResponse[i].statusName;
                    break;
                }
            }
            break;
        }

        case "urgency":{
            getAllUrgencies();
            for (let i=0;i<urgencyListResponse.length;i++){
                if (item_id==urgencyListResponse[i].urgencyId){
                    found_name=urgencyListResponse[i].urgencyName;
                    break;
                }
            }
        }
    }
    return found_name;
}

export function getAllUrgencies() {
    $.ajax({
        method: 'GET',
        url: 'https://localhost:7025/api/Urgencies',
        // data: null
        async: false,
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        success: function (response) {
            urgencyListResponse=response;
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
}

export function getAllStatuses() {
    $.ajax({
        method: 'GET',
        url: 'https://localhost:7025/api/Status',
        async: false,
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        success: function (response) {
            statusListResponse=response;
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
}



export function isOverflown(element:HTMLElement) {
    return element.scrollHeight > element.clientHeight || element.scrollWidth > element.clientWidth;
}

export function deleteTaskPerId(taskId:number){
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

export function deleteCategoryPerId(categoryId:number){
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
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
    document.location.reload();

}




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
