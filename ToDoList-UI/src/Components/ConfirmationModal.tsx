import { ExclamationCircleOutlined } from '@ant-design/icons';
import { DeleteOutlined } from '@ant-design/icons';
import { Button, Modal, Space } from 'antd';
import React, { useState } from 'react';

const confirm = (modalTitle:string, modalContent:string, modalOkText:string, modalCancelText:string, doSomtehing:(params:any)=>any) => {
    Modal.confirm({
        title: modalTitle,
        icon: <ExclamationCircleOutlined />,
        content: modalContent,
        okText: modalOkText,
        cancelText: modalCancelText,
        onOk(){
            doSomtehing("1");
        }
    });
};

interface Props {
    modalTitle: string,
    modalContent:string,
    modalOkText:string,
    modalCancelText:string,
    doSomething: (params: any) => any;
}

const ConfirmationModal: React.FC<Props> = (props) => (
    <Space>
        <DeleteOutlined onClick={()=>confirm(props.modalTitle,props.modalContent,props.modalOkText, props.modalCancelText,props.doSomething)}>Confirm</DeleteOutlined>
    </Space>
);


export default ConfirmationModal;
