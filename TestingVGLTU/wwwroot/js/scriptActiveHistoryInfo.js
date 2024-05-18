const cardList = document.querySelectorAll('.card');
const infoList = parent.document.getElementById('infoBlock');
const btnBack = parent.document.getElementById('back');

cardList.forEach(i => {
    
    i.children[1].children[1].onclick = () => {
        let type = i.children[0].children[0].children[0].children[0].textContent;
        let name = i.children[0].children[1].children[0].children[0].textContent;

        infoList.children[0].children[0].innerText = name;
        infoList.children[1].children[0].innerText = type;

        infoList.children[0].style.display = "flex";
        infoList.children[1].style.display = "flex";
        btnBack.style.display = "flex";

    }
});