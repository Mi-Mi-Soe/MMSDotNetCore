//getProducts();
const tblProduct = "products";
const addToCartList = "addToCartList";
let cartList = [];
//getProducts();
//createProduct("Watch",30000);
getProductTable();

function getProductTable() {
    let lst = getProducts();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
        <tr>
        <th scope="row">${++count}</th>
        <td>${item.productName}</td>
        <td>${item.productPrice}</td>
         <td><button type="button" class="btn btn-success" onclick="addToCart('${item.id}')">Add</button></td>
      </tr>
      `;
        htmlRows += htmlRow;
    });
    $('#tblBody').html(htmlRows);
}

function addToCartTable() {
    let totalPrice = 0;
    let htmlRows = `<h5>Prdouct<span class="price" style="color:black;float:right"><i class="fa fa-shopping-cart"></i> <b>${cartList.length}</b></span></h5>`;
    cartList.forEach(item => {
        const htmlRow = `
        <p>${item.productName}</a> <span class="price" style="float:right">${item.productPrice}</span></p>
      `;
        totalPrice += item.productPrice;
        htmlRows += htmlRow;
    })
    htmlRows += `<p><b>Total</b> <span class="price" style="color:black;float:right"><b>${totalPrice}</b></span></p>`;
    $('#cartId').html(htmlRows);
}

function getProducts() {
    const products = localStorage.getItem(tblProduct);
    console.log(products);

    let lst = [];
    if (products !== null) {
        lst = JSON.parse(products);
    }
    console.log(lst);
    return lst;
}

function createProduct(name, price) {
    let lst = getProducts();
    console.log(lst);
    console.log(typeof lst);
    const requestModel = {
        id: uuidv4(),
        productName: name,
        productPrice: price
    };
    lst.push(requestModel);
    const json = JSON.stringify(lst);
    localStorage.setItem(tblProduct, json);
    console.log("Saving Successful.");
}

function addToCart(productId) {
    let lst = getProducts();
    const items = lst.filter(x => x.id === productId);
    console.log(items);
    if (items.length == 0) {
        console.log("No data found");
        return;
    }
    const item = items[0];

    cartList.push(item);
    console.log(cartList);
    addToCartTable();
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}
