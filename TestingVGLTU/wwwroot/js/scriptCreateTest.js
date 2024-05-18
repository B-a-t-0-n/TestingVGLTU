const btnBack = parent.document.getElementById('back');
const addTest = document.getElementById('cardCreate');
const cardInfoList = document.querySelectorAll('.card-info')

cardInfoList.forEach(i => {
    i.children[1].children[0].onclick = () => {
        btnBack.style.display = "flex";
    }
})
addTest.children[0].onclick = () => btnBack.style.display = "flex";

