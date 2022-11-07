import React from 'react';
import '../css/TaskWindow.css';
import * as $ from "jquery";


function TaskWindow() {

    return (
        <div className="task_window_container">
        <div id="taskWindow" className="task_window_display window_hidden">
            <div id="currentCategoryNameDiv">placeholder</div>
        </div>
        </div>
    );
}

export default TaskWindow;

