function sortByPoints(a, b) {
    return (a.Points > b.Points) ? -1 : ((a.Points < b.Points) ? 1 : 0);
}

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
        data.sort(sortByPoints);
        $.each(data, function(i, recipe) {
            $('#recipeList')
                .append('<a class="recipe" href="recipes/' +
                    recipe["Id"] + '">' +
                    recipe["Name"] + '  (' +
                    recipe["Points"] + ')' + '</a>');
        });
    });

});