import React from 'react';
import '../css/Body.css';
import Sidebar from "./Sidebar";
import TaskWindow from "./TaskWindow";
function Body() {
    return (
        <div className="main_container">
        <Sidebar/>
            <TaskWindow/>
        </div>
    );
}

export default Body;
