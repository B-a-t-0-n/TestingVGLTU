const ListRowQestion = document.querySelectorAll(".row-qestion");

ListRowQestion.forEach((item) => {
    item.children[3].children[1].onclick = () => {
        item.remove();
    }
});

ListRowQestion.forEach((item) => {
    item.children[3].children[0].onclick = () => {
        window.location.href = '..\\teacher\\create_question.html';
    }
});