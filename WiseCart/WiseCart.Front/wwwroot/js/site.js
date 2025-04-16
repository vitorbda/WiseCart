// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var Loading = {
    // Elemento HTML do loading
    element: $('<div class="loading-overlay">' +
        '<div class="loading-content">' +
        '<div class="loading-spinner"></div>' +
        '<div class="loading-message"></div>' +
        '</div></div>'),

    // Inicializa o loading (adiciona ao DOM)
    Initialize: function () {
        if ($('.loading-overlay').length === 0) {
            $('body').append(this.element);
        }
    },

    // Inicia o loading com mensagem opcional
    StartLoading: function (message) {
        this.Initialize();

        // Configura a mensagem se fornecida
        if (message && typeof message === 'string') {
            this.element.find('.loading-message').text(message).show();
        } else {
            this.element.find('.loading-message').hide();
        }

        // Exibe o loading
        this.element.fadeIn(200);
    },

    // Para o loading
    StopLoading: function () {
        this.element.fadeOut(200, function () {
            $(this).find('.loading-message').empty();
        });
    }
};