import axios from "axios";
import {TempConst} from "../TempConst";

export const axiosInstance = axios.create({
    baseURL: TempConst.BaseApiUrl
});