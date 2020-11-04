document.forms[0].onsubmit = () => {
    let formData = new FormData(document.forms[0]);
    let alertEl = document.getElementById('success-alert');
    fetch('', {
        method: 'post',
        body: new URLSearchParams(formData)
    })
        .then(() => {
            alertEl.style.display = 'flex';
        });
    return false;
};