const elementsItem = document.querySelectorAll(".catalog_sorted_elements_item");
const itemStars = document.querySelectorAll(".item_stars");
const itemImg = document.querySelectorAll(".catalog_sorted_elements_item_img");
const itemName = document.querySelectorAll(".catalog_sorted_elements_item_name");
const itemLink = document.querySelectorAll(".item_change_link");
const compareOrLike = document.querySelectorAll(".change_compare_like");
const vendorCode = document.querySelectorAll(".change_vendor_code");
const changeAvailability = document.querySelectorAll(".item_change_availability");
const itemPrice = document.querySelectorAll(".catalog_sorted_elements_item_price");
const buy = document.querySelectorAll(".buy");
for (let i = 0; i < elementsItem.length; i++) {
    const Item = elementsItem[i];
    Item.addEventListener("mouseover", function()
    {   this.classList.add("item_change");
        itemStars[i].classList.remove("hidden")
        itemImg[i].classList.add("item_img_change");
        itemName[i].classList.add("item_name_change");
        itemLink[i].classList.remove("hidden");
        compareOrLike[i].classList.remove("hidden");
        vendorCode[i].classList.remove("hidden");
        changeAvailability[i].classList.remove("hidden");
        itemPrice[i].classList.add("item_change_price_change");
        buy[i].classList.remove("hidden");
    })

};
for (let i = 0; i < elementsItem.length; i++) {
    const Item = elementsItem[i];
    Item.addEventListener("mouseout", function(){
        this.classList.remove("item_change");
        itemStars[i].classList.add("hidden");
        itemImg[i].classList.remove("item_img_change");
        itemName[i].classList.remove("item_name_change");
        itemLink[i].classList.add("hidden");
        compareOrLike[i].classList.add("hidden");
        vendorCode[i].classList.add("hidden");
        changeAvailability[i].classList.add("hidden");
        itemPrice[i].classList.remove("item_change_price_change");
        buy[i].classList.add("hidden");

    });

};

