const tblblog = "blogs";
let blogId = null;

// CreateBlog();
// UpdateBlog("e0c6d597-e588-4380-9e54-e39acf722ffe", 'test', 'test', 'test');
// DeleteBlog("e0c6d597-e588-4380-9e54-e39acf722ffe");
getBlogTable();

function ReadBlog() {
    let lst = getBlog();
    console.log(lst);
}

function CreateBlog(title, author, content) {
    let lst = getBlog();
    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };
    lst.push(requestModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblblog, jsonBlog);

    successMessage("Saving Successful.");
    clearControl();
}

function EditBlog(id) {
    let lst = getBlog();

    const items = lst.filter(x => x.id === id);
    console.log(items.length);

    if (items.length === 0) {
        console.log("no data found");
        errorMessage("no data found")
        return;
    }
    let item = items[0];
    blogId = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
    $('#txtTitle').focus();
}

function UpdateBlog(id, title, author, content) {
    let lst = getBlog();

    const items = lst.filter(x => x.id === id);
    console.log(items.length);

    if (items.length === 0) {
        console.log("no data found");
        errorMessage("no data found")
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblblog, jsonBlog);
    successMessage("Updating Successful.")
}

function DeleteBlog(id) {
    let result = confirm("Are you sure want to delete?");
    if(!result)return;

    let lst = getBlog();
    const items = lst.filter(x => x.id === id);
    if (items.length === 0) {
        console.log("no data found");
        return;
    }
    lst = lst.filter(x => x.id !== id)
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblblog, jsonBlog);

    successMessage("Deleting Succesful");
    getBlogTable();
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function getBlog() {
    const blogs = localStorage.getItem(tblblog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}

$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (blogId === null) {
        CreateBlog(title, author, content);
    }
    else {
        UpdateBlog(blogId,title,author,content);
        blogId = null;
    }
    getBlogTable();
})

function successMessage(message) {
    alert(message);
}

function errorMessage(message) {
    alert(message);
}

function clearControl() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    const lst = getBlog();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
       <tr>
            <td>
                <button type="button" class="btn btn-warning" onclick="EditBlog('${item.id}')">Edit</button>
                <button type="button" class="btn btn-danger" onclick="DeleteBlog('${item.id}')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
       </tr>` ;
        htmlRows += htmlRow;
    });
    $('#tbody').html(htmlRows);
}