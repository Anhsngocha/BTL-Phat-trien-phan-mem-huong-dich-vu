var form1 = document.querySelector('#login')
var form2 = document.querySelector('#sign-up')
var email = document.getElementById('enter-email')
var emaildk = document.getElementById('enter-email-sign-up')
var password = document.getElementById('enter-password')
var passworddk = document.getElementById('enter-password-sign-up')
var fname = document.getElementById('enter-fullname')
var password2 = document.getElementById('enter-password-again')

form1.addEventListener('submit', e => {
    e.preventDefault();

    checkInputsForm1();
});

form2.addEventListener('submit', e => {
    e.preventDefault();

    checkInputsForm2();
});

function checkInputsForm1() {
    const emailValue = email.value.trim();
    const passwordValue = password.value.trim();
    if (emailValue === '') {
        setErrorFor(email, 'Email không được để trống!!!')
    } else if (!isEmail(emailValue)) {
        setErrorFor(email, 'Email không hợp lệ');
    } else {
        setSuccessFor(email);
    }
    if (passwordValue === '') {
        setErrorFor(password, 'Mật khẩu không được để trống');
    } else {
        setSuccessFor(password);
    }
}

function checkInputsForm2() {
    // trim to remove the whitespaces
    const fnameValue = fname.value.trim();
    const emailValue = emaildk.value.trim();
    const passwordValue = passworddk.value.trim();
    const password2Value = password2.value.trim()
    if (fnameValue === '') {
        setErrorFor(fname, 'Họ tên không được để trống');
    } else {
        setSuccessFor(fname);
    }

    if (emailValue === '') {
        setErrorFor(emaildk, 'Email không được để trống');
    } else if (!isEmail(emailValue)) {
        setErrorFor(emaildk, 'Email không hợp lệ');
    } else {
        setSuccessFor(emaildk);
    }

    if (passwordValue === '') {
        setErrorFor(passworddk, 'Mật khẩu không được để trống');
    } else {
        setSuccessFor(passworddk);
    }

    if (password2Value === '') {
        setErrorFor(password2, 'Xác nhận mật khẩu không được để trống');
    } else if (passwordValue !== password2Value) {
        setErrorFor(password2, 'Xác nhận mật khẩu không trùng với mật khẩu');
    } else {
        setSuccessFor(password2);
    }
}

function setErrorFor(input, message) {
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    formControl.className = 'form-control error';
    small.innerText = message;
}

function setSuccessFor(input) {
    const formControl = input.parentElement;
    formControl.className = 'form-control success';
}

function isEmail(email) {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(email);
}

var formSignup = document.querySelector('.box-signup')
var formSignin = document.querySelector('.box-login')

function showSignup(element) {
    formSignup.style.display = 'block'
    formSignin.style.display = 'none'
}

function showSignin(element) {
    formSignin.style.display = 'block'
    formSignup.style.display = 'none'

}