window.redirectTo = function (url, delay) {
    setTimeout(() => {
        window.location.href = url;
    }, delay);
};
