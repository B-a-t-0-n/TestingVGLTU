const ListCardInfo = document.querySelectorAll(".card-info");

ListCardInfo.forEach((item) => {
    item.children[0].children[0].children[1].onclick = () => {
        item.remove();
    }
});