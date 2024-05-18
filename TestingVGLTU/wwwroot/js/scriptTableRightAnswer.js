const ListRowQestion = document.querySelectorAll(".row-qestion");
const btnCreate = document.getElementById('create').children[0];

btnCreate.onclick = () => window.location.href = '..\\teacher\\create_test_page_3.html';

ListRowQestion.forEach((item) => {
    console.log();
    item.children[parseInt(item.children.length) - parseInt(1)].children[0].onclick = () => {
        item.remove();
    }
});

