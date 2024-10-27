let api_endpoint = '';
console.log("config url", document.URL)
if (document.URL.includes('localhost')) {
    api_endpoint = "https://localhost:7248/"
}else{
    api_endpoint = ""
}


export default {
    api_endpoint
}