const listBtn = document.querySelectorAll('.rfbtn');



for (let i = 0; i < listBtn.length; i++) {
    listBtn[i].onclick = () => {
        
        for (let j = 0; j < listBtn.length; j++) {
            listBtn[j].classList.remove("rfbtnActive");
        }
        listBtn[i].classList.add("rfbtnActive");
    } 
} 