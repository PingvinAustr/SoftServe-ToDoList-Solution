import { Button, Form, Input, Modal, Select } from 'antd';
import React, { useState } from 'react';
import * as $ from "jquery";
import currentOpenedCategory from "../js/currentOpenedCategory";
import {OpenSelectedCategory} from "./CategorySidebarItems";

const { Option } = Select;
// ============= RESPONSE ARRAYS =========
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



getAllUrgencies();
getAllStatuses();

var urgencyListItems=urgencyListResponse.map((item:Urgency)=>
    <Option key={item.urgencyId.toString()}>{item.urgencyName}</Option>
);

var statusListItems=statusListResponse.map((item:Status)=>
    <Option key={item.statusId.toString()}>{item.statusName}</Option>
);


interface Values {
    title: string;
    description: string;
    modifier: string;
}

interface CollectionCreateFormProps {
    open: boolean;
    onCreate: (values: Values) => void;
    onCancel: () => void;
}

const CollectionCreateForm: React.FC<CollectionCreateFormProps> = ({
                                                                       open,
                                                                       onCreate,
                                                                       onCancel,
                                                                   }) => {

    const onUrgencyChange = (value: string) => {
        form.setFieldsValue(value);
    };

    const onStatusChange = (value: string) => {
        form.setFieldsValue(value);
    };

    const onReset = () => {
        form.resetFields();
    };

    const [form] = Form.useForm();
    return (
        <Modal
            open={open}
            title="Specify task details"
            okText="Create"
            cancelText="Cancel"
            onCancel={onCancel}
            onOk={() => {
                form
                    .validateFields()
                    .then(values => {
                        form.resetFields();
                        onCreate(values);
                    })
                    .catch(info => {
                        console.log('Validate Failed:', info);
                    });
            }}
        >
            <Form
                form={form}
                layout="vertical"
                name="form_in_modal"
                initialValues={{ modifier: 'public' }}
            >
                <Form.Item
                    name="taskName"
                    label="Task name"

                    rules={[{ required: true, message: 'Please input title of the task!' }]}
                >
                    <Input maxLength={20} showCount={true} />
                </Form.Item>
                <Form.Item name="taskDescription" label="Task description" rules={[{required:true, message:'Please input task description!'}]}>
                    <Input maxLength={100} showCount={true} type="textarea" />
                </Form.Item>

                <Form.Item name="taskUrgency" label="Task Urgency" rules={[{ required:true, message:'Please select task status!' }]}>
                    <Select
                        placeholder="Select task urgency"
                        onChange={onUrgencyChange}
                        allowClear
                    >
                        {urgencyListItems}
                    </Select>
                </Form.Item>



                <Form.Item name="taskStatus" label="Task Status" rules={[{ required: true, message:'Please select task urgency!' }]}>
                    <Select
                        placeholder="Select task status"
                        onChange={onStatusChange}
                        allowClear
                    >
                        {statusListItems}
                    </Select>
                </Form.Item>


                <Form.Item>
                    <Button htmlType="button" onClick={onReset}>
                        Reset
                    </Button>

                </Form.Item>

            </Form>
        </Modal>
    );
};

const FormModal: React.FC = () => {
    const [open, setOpen] = useState(false);

    const onCreate = (values: any) => {
        console.log('Received values of form: ', values);
        AddTask(values);
        setOpen(false);
    };

    return (
        <div>
            <Button
                type="primary"
                onClick={() => {
                    setOpen(true);
                }}
            >
                Add task
            </Button>
            <CollectionCreateForm
                open={open}
                onCreate={onCreate}
                onCancel={() => {
                    setOpen(false);
                }}
            />
        </div>
    );
};

export default FormModal;




// ============== AJAX ==========
function getAllUrgencies() {
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

function getAllStatuses() {
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

function AddTask(values:any){
    $.ajax({
        method: 'POST',
        url: 'https://localhost:7025/api/Task_',
        async: false,
        data:{
          taskName:values["taskName"],
          taskDescription:values["taskDescription"],
            taskUrgency:values["taskUrgency"],
            taskStatus:values["taskStatus"],
            taskCategory:currentOpenedCategory.category_id
        },
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        success: function (response) {
            console.log("success");
        },
        error: function (response, status, error) {
            console.log(JSON.stringify(response));
        }
    });
    OpenSelectedCategory(currentOpenedCategory.category_id);
}