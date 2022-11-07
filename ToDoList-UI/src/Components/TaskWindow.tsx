import React from 'react';
import '../css/TaskWindow.css';
import * as $ from "jquery";

import { Button, Popconfirm, Space, Upload } from 'antd';
import { Layout } from 'antd';
import { Col, Row } from 'antd';
const { Header, Footer, Sider, Content } = Layout;


function TaskWindow() {
/*
    return (
        <Layout id="Layout1" hidden={true} style={{background:"#282c34"}}>
            <Content id="Content1" style={{margin:"7% 10% 7% 10%", background:"#f0f2f5", padding:"20px"}}>
                <Row style={{fontSize:"24px"}}>
                    <Col span={21}>
                        <div id="currentCategoryNameDiv">placeholder</div>
                    </Col>
                    <Col span={3}>
                        <Button size={"large"} type="primary">Add task</Button>
                    </Col>
                </Row>
            </Content>
            <Footer style={{textAlign:"center"}}>Created by Chushenko Yaroslav, SoftServe, 2022</Footer>
        </Layout>
    );
    */

    return (
        <Layout id="Layout1" hidden={true} style={{background:"#282c34"}}>

            <Content id="Content1" style={{margin:"7% 10% 7% 10%", background:"#f0f2f5", padding:"20px"}}>

            </Content>
            <Footer style={{textAlign:"center"}}>Created by Chushenko Yaroslav, SoftServe, 2022</Footer>
        </Layout>
    );

}

export default TaskWindow;

