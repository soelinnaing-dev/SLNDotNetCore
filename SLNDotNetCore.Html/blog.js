const tblblog = "blogs";

//CreateBlog();
// UpdateBlog("e0c6d597-e588-4380-9e54-e39acf722ffe", 'test', 'test', 'test');
// DeleteBlog("e0c6d597-e588-4380-9e54-e39acf722ffe");

function ReadBlog() {
    const blogs = localStorage.getItem(tblblog);
    console.log(blogs);
}

function CreateBlog() {
    const blogs = localStorage.getItem(tblblog);
    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    const requestModel = {
        id: uuidv4(),
        title: "test title",
        author: "test author",
        content: "test content"
    };
    lst.push(requestModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblblog, jsonBlog);
}

function UpdateBlog(id, title, author, content) {
    const blogs = localStorage.getItem(tblblog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    
    const items = lst.filter(x => x.id === id);
    console.log(items.length);
    
    if (items.length === 0) {
        console.log("no data found");
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
}

function DeleteBlog(id){
    const blogs = localStorage.getItem(tblblog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    const items = lst.filter(x => x.id === id);
    if (items.length === 0) {
        console.log("no data found");
        return;
    }
    lst = lst.filter(x => x.id!==id)
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblblog, jsonBlog);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}
