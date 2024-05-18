const btnStudent = document.getElementById('btnStudent');
const btnTeacher = document.getElementById('btnTeacher');
const listTextBox = document.getElementById('studentInput');

btnStudent.onclick = () => {
    for (let i = 0; i < listTextBox.children.length; i++) {
        for (let j = 0; j < listTextBox.children[i].children.length; j++) {
            listTextBox.children[i].children[j].style.display = 'flex';
        }
    }    
};

btnTeacher.onclick = () => {
    for (let i = 0; i < listTextBox.children.length; i++) {
        for (let j = 0; j < listTextBox.children[i].children.length; j++) {
            listTextBox.children[i].children[j].style.display = 'none';
        }
    }    
};