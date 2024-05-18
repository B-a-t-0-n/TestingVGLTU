const btnGoOwer = document.getElementById('btnGoOwer');
const listMenu = parent.document.getElementById('menu-btn').children;

btnGoOwer.onclick = () =>{
    for (let j = 0; j < listMenu.length; j++) {
        listMenu[j].classList.remove("active");
    }
    listMenu[2].classList.add("active");

    window.location.href = '..\\student\\active_Student.html';

}