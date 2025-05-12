const listBtn = document.querySelectorAll('.rfbtn');
document.addEventListener("DOMContentLoaded", function () {  
   const btnStudent = document.getElementById("btnStudent");  
   const btnTeacher = document.getElementById("btnTeacher");  
   const isTeacherInput = document.createElement("input");  

   isTeacherInput.type = "hidden";  
   isTeacherInput.name = "IsTeacher";  
   isTeacherInput.value = "false";  
   document.querySelector("form").appendChild(isTeacherInput);  

   btnStudent.addEventListener("click", function () {  
       btnStudent.classList.add("rfbtnActive");  
       btnTeacher.classList.remove("rfbtnActive");  
       isTeacherInput.value = "false";  
   });  

   btnTeacher.addEventListener("click", function () {  
       btnTeacher.classList.add("rfbtnActive");  
       btnStudent.classList.remove("rfbtnActive");  
       isTeacherInput.value = "true";  
   });  
});


for (let i = 0; i < listBtn.length; i++) {
    listBtn[i].onclick = () => {
        
        for (let j = 0; j < listBtn.length; j++) {
            listBtn[j].classList.remove("rfbtnActive");
        }
        listBtn[i].classList.add("rfbtnActive");
    } 
} 