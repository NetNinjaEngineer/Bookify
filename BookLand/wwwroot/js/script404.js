const line1 = "We are sorry.";
const line2 = "But the page you are looking for";
const line3 = "cannot be found.";

const textElementLine1 = document.getElementById("line1");
const textElementLine2 = document.getElementById("line2");
const textElementLine3 = document.getElementById("line3");

let index1 = 0;
let index2 = 0;
let index3 = 0;

function typeWriter(line, textElement, index, callback) {
    if (index < line.length) {
        textElement.innerHTML += line.charAt(index);
        setTimeout(() => typeWriter(line, textElement, index + 1, callback), 100);
    } else {
        callback && callback();
    }
}

window.onload = function () {
    typeWriter(line1, textElementLine1, 0, () => {
        typeWriter(line2, textElementLine2, 0, () => {
            typeWriter(line3, textElementLine3, 0);
        });
    });
};
