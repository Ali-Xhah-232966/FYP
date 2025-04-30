window.showModal = (modalId) => {
    new bootstrap.Modal(document.getElementById(modalId)).show();
};

window.hideModal = (modalId) => {
    new bootstrap.Modal(document.getElementById(modalId)).hide();
};