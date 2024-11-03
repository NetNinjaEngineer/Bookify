// Function to handle the hover animation
function animateButton(button, direction) {
    let animation;
    if (direction === 'hover') {
        animation = [
            { transform: 'translateX(0)' },
            { transform: 'translateX(10px)' },
            { transform: 'translateX(0)' }
        ];
    } else {
        animation = [
            { transform: 'translateX(0)' },
            { transform: 'translateX(-10px)' },
            { transform: 'translateX(0)' }
        ];
    }

    button.animate(animation, {
        duration: 1200,
        iterations: 2,
        easing: 'ease-in-out'
    });
}

// Get the sign-up button
const signUpBtn = document.querySelector('.signup-btn');

// Add hover event listeners for the button
signUpBtn.addEventListener('mouseenter', () => animateButton(signUpBtn, 'hover'));
signUpBtn.addEventListener('mouseleave', () => animateButton(signUpBtn, 'non-hover'));
