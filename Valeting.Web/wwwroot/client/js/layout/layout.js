var Master = (function () {

    $(document).ready(function () {
        Menu.ToggleMenu();
    });

    var Menu = (function () {

        function ToggleMenu() {
            $('#btnAbrirMenu').on('click', function () {
                $('#navMenu').css('width', '250px');
            });

            $('#btnFecharMenu').on('click', function () {
                $('#navMenu').css('width', '0');
            });
        }

        return {
            ToggleMenu: ToggleMenu
        }

    })();

})();