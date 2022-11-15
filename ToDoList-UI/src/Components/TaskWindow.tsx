import React from 'react';
import '../css/TaskWindow.css';
import Sidebar from "./Sidebar";
import { Layout } from 'antd';
import {NotificationOutlined} from "@ant-design/icons";
import TasksTable from "./TasksTable";
const { Header, Footer, Sider, Content } = Layout;



function TaskWindow() {

    return (
        <Layout style={{height:"100%"}}>
            <Sider id={"Sider1"} width={"250px"} collapsible={true} breakpoint={"md"} collapsedWidth={0} onCollapse={()=>sidebarSizeChanger()}>
                <Sidebar/>
            </Sider>
            <Layout id="Layout1" hidden={true} style={{background: "#282c34"}}>
                <Content id="Content1" style={{margin:"7% 10% 7% 10%", background:"#f0f2f5", padding:"20px"}}>
                <TasksTable categoryId={1}/>
                </Content>
                <Footer style={{textAlign:"center"}}>
                    Created by Chushenko Yaroslav, SoftServe, 2022
                </Footer>
            </Layout>
        </Layout>
    );


}

export default TaskWindow;

function sidebarSizeChanger(){
    if (Math.max(window.innerWidth)<768){


        if (document.getElementById("Sider1")!.style.width != "250px") {
            //Sider is opened
            document.getElementById("Layout1")!.style.display = "none";
        } else {
            document.getElementById("Layout1")!.style.display = "flex";
        }
    }

    //alert(Math.max(window. innerWidth));
}