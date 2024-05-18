
const counterInput = document.getElementById('counter-input');

document.getElementById('btn-minus').onclick = () => {
    let num = parseInt(counterInput.value);

    if(num > 1){
        counterInput.value = num - 1;
    } 
}

document.getElementById('btn-plus').onclick = () => {
    let num = parseInt(counterInput.value);

    if(num < 99){
        counterInput.value = num + 1;
    } 
} 
