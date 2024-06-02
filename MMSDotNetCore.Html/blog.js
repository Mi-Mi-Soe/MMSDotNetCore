const tblBlog = "blogs";
let blogId=null;
getTables();
//createBlogs();
//updateBlog("4ea2b691-f82f-44fc-a43f-a7a5a6ed256c","lisa","lisa","lisa")
//deleteBlog("06ac875f-31c4-489b-8f2d-6376da9e1063");

function readBlogs() {
    let lst = localStorage.getBlogs();
    console.log(lst);
}

function createBlogs(title, author, content) {
    let lst = getBlogs();
    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };
    console.log(typeof lst);
    lst.push(requestModel);

    const json = JSON.stringify(lst);
    localStorage.setItem(tblBlog, json);
    successMessage("Saving Successful.");
    clearControl();
}

function updateBlog(id, title, author, content) {
    let lst = getBlogs();
    const items = lst.filter(x => x.id === id);
    console.log(items);
    if (items.length == 0) {
        console.log("No data found");
        errorMessage("No data found");
        return;
    }

    const item = items[0];
    item.id = id;
    item.title = title;
    item.author = author;
    item.content = content;
    let index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const json = JSON.stringify(lst);
    localStorage.setItem(tblBlog, json);
    console.log('Updating successful');
    successMessage('Updating successful');
}

function deleteBlog(id) {
    let lst = getBlogs();
    const items = lst.filter(x => x.id === id);
    console.log(items);
    if (items.length == 0) {
        console.log("No data found");
        errorMessage("No data found");
        return;
    }
    lst = lst.filter(x => x.id !== id);
    const json = JSON.stringify(lst);
    localStorage.setItem(tblBlog, json);
    console.log('Deleting successful');
    successMessage('Deleting successful');
    getTables();
}

function editBlog(id) {
    let lst = getBlogs();
    const items = lst.filter(x => x.id === id);
    console.log(items);
    if (items.length == 0) {
        console.log("No data found");
        errorMessage("No data found");
        return;
    }
    const item = items[0];
    blogId = item.id
    $("#txtTitle").val(item.title);
    $("#txtAuthor").val(item.author);
    $("#txtContent").val(item.content);
    $("#txtTitle").focus();
}

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

$('#btnCancel').click(function () {
    clearControl();
});

$('#btnSave').click(function () {
    const title = $("#txtTitle").val();
    const author = $("#txtAuthor").val();
    const content = $("#txtContent").val();

    if (blogId === null) {
        createBlogs(title, author, content);
    } else {
        updateBlog(blogId, title, author, content);
        clearControl();
        blogId = null;
    }
    getTables();

});

function clearControl() {
    $("#txtTitle").val('');
    $("#txtAuthor").val('');
    $("#txtContent").val('');
    $("#txtTitle").focus();
}

function successMessage(message) {
    alert(message);
}

function errorMessage(message) {
    alert(message);
}

function getTables() {
    let lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
        <tr>
        <th scope="row">${++count}</th>
        <td><button type="button" class="btn btn-danger" onclick="deleteBlog('${item.id}')">Delete</button></td>
        <td><button type="button" class="btn btn-success" onclick="editBlog('${item.id}')">Edit</button></td>
        <td>${item.title}</td>
        <td>${item.author}</td>
        <td>${item.content}</td>
      </tr>
      `;
        htmlRows += htmlRow;
    });
    $('#tblBody').html(htmlRows);
}
