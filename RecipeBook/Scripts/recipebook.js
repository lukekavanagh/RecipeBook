$(document).ready(function() {
    $('#welcome').hide(300).delay(1000).slideToggle(30000);
    $('.cow_image').hide(300).delay(1000).slideToggle(30000);

    var $categories = $.getJSON('api/categories', function(data) {
        $.each(data, function(i, category) {
            $('#categoryList')
                .append('<a class="category" href="categories/' +
                category["Id"] + '">' +
                category["Name"] + '</a>');
        });
    });
    var $recipes = $.getJSON('api/recipes', function(data) {
        $.each(data, function(key, val) {
            $.each(val, function(key, val) {
                console.log(key + " : " + val);
            });
        });
    });

});