const select = document.getElementById("type-question");
const typeQuestions = document.querySelectorAll('.right-answer');

select.oninput = () => {
    toggle(typeQuestions,parseInt(select.value) - parseInt(1));
}

function toggle(elements, index){
    elements.forEach(i => {
       i.classList.remove("active")
    });

    elements[index].classList.add("active");
}