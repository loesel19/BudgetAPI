import config from "@/modules/config";
import Toast from "./Toast";

export default {
    async Get(url = "", after = () => { }) {
        console.log("in get")
        let fullUrl = config.api_endpoint + url
        let apiResponse = await fetch(fullUrl, {
            method: "Get",
            cache: 'no-cache',
            headers: new Headers({ 'content-type': 'application/json' }),
        });
        let response = await apiResponse.json();

        if (response.status >= 500) {
            Toast.Error("An error occurred on the server.")
        }
        else if (response.status >= 400) {

        }
        else if (response.status >= 300) {

        } else {
            after(response)
        }
        return response

    },
    async Post(url = "", data = {}, after = () => { }) {
        console.log("in post")
        let fullUrl = config.api_endpoint + url
        let apiResponse = await fetch(fullUrl, {
            method: "POST",
            cache: 'no-cache',
            headers: new Headers({ 'content-type': 'application/json' }),
            body: JSON.stringify(data)
        });
        let response = await apiResponse.json();

        if (response.status >= 500) {
            Toast.Error("An error occurred on the server.")
        }
        else if (response.status >= 400) {

        }
        else if (response.status >= 300) {

        } else {
            after(response)
        }
        return response

    },

}