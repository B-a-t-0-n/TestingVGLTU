const listMenu = document.getElementById('menu-btn').children;

for (let i = 0; i < listMenu.length; i++) {
    listMenu[i].onclick = () => {
        for (let j = 0; j < listMenu.length; j++) {
            listMenu[j].classList.remove("active");
        }
        listMenu[i].classList.add("active");
    } 
} 