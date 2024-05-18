const ListRow = document.querySelectorAll(".row-Group");

ListRow.forEach((item) => {
    item.children[2].children[0].onclick = () => {
        item.remove();
    }
});