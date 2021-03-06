import { combineReducers } from "redux";
import HomePageReducer from "../containers/HomePageContainer/reducer";
import CreateUserPageReducer from "../containers/CreateUserContainer/reducer";
import LoginPageReducer from "../containers/LoginPageContainer/reducer";
import MainPageReducer from "../containers/MainPageContainer/reducer";
export default combineReducers({
  homePageReducer: HomePageReducer,
  createUserPageReducer: CreateUserPageReducer,
  loginPageReducer: LoginPageReducer,
  mainPageReducer: MainPageReducer
});
