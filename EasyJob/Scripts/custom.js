$(document).ready(function () {
    console.log('execute JQuery');
    $(".buddys").on("swiperight", function () {
        swipeRightAction($(this));
    });

    $(".buddys").on("swipeleft", function () {
        swipeLeftAction($(this));
    });
    $(".likeBtnJS").click(function () {
        console.log("likeBtnJS");
        console.log($(this).attr('id'));
        $.ajax({
            type: "POST",
            url: '/JobSeeker/Like/' + $(this).attr('id'),
        });
        swipeRightAction($("#buddy" + $(this).attr('id')));
    });
    $(".dissBtnJS").click(function () {
        console.log("dissBtnJS");
        console.log($(this).attr('id'));
        $.ajax({
            type: "POST",
            url: '/JobSeeker/Dislike/' + $(this).attr('id'),
        });
        swipeRightAction($("#buddy" + $(this).attr('id')));
        swipeLeftAction($("#buddy" + $(this).attr('id')));
    });
    $(".likeBtnJO").click(function () {
        console.log("likeBtnJO");
        console.log($(this).attr('id'));
        $.ajax({
            type: "POST",
            url: '/JobOffer/Like/' + $(this).attr('id'),
        });
        swipeRightAction($("#buddy" + $(this).attr('id')));
    });
    $(".dissBtnJO").click(function () {
        console.log("dissBtnJO");
        console.log($(this).attr('id'));
        $.ajax({
            type: "POST",
            url: '/JobOffer/Dislike/' + $(this).attr('id'),
        });
        swipeRightAction($("#buddy" + $(this).attr('id')));
        swipeLeftAction($("#buddy" + $(this).attr('id')));
    });

});
function swipeRightAction(buddy) {
    console.log('moveRight');
    $(buddy).addClass('rotate-left').delay(700).fadeOut(1);
    $('.buddys').find('.status').remove();
    $(buddy).append('<div class="status like">Like!</div>');

    /*if ($(buddy).is(':last-child')) {
        $('.buddys:nth-child(1)').removeClass('rotate-left rotate-right').fadeIn(300);
    } else {
        $(buddy).next().removeClass('rotate-left rotate-right').fadeIn(400);
    }*/

}

function swipeLeftAction(buddy) {
    console.log('moveLeft');
    $(buddy).addClass('rotate-right').delay(700).fadeOut(1);
    $('.buddys').find('.status').remove();
    $(buddy).append('<div class="status dislike">Dislike!</div>');

    /*if ($(buddy).is(':last-child')) {
        $('.buddys:nth-child(1)').removeClass('rotate-left rotate-right').fadeIn(300);
        alert('OUPS');
    } else {
        $(buddy).next().removeClass('rotate-left rotate-right').fadeIn(400);
    }*/
}