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

// Get all buttons that need the hover animation
const createAccountBtn = document.querySelector('.create-account-btn');
const loginBtn = document.querySelector('.login-btn');

createAccountBtn.addEventListener('mouseenter', () => animateButton(createAccountBtn, 'hover'));
createAccountBtn.addEventListener('mouseleave', () => animateButton(createAccountBtn, 'non-hover'));

loginBtn.addEventListener('mouseenter', () => animateButton(loginBtn, 'hover'));
loginBtn.addEventListener('mouseleave', () => animateButton(loginBtn, 'non-hover'));
