import * as React from "react";
import {Route, Routes} from 'react-router';
import {Layout} from './components/Layout';
import {Home} from './components/home/Home';
import {LoanApplication} from './components/loan-application/LoanApplication';
import './custom.css'
import {Signup} from "./components/signUp/Signup";
import {Unsubscribe} from "./components/unsubscribe/Unsubscribe";

export const App = () => {
    return (
        <Layout>
            <Routes>
                <Route path='/' Component={Home} />
                <Route path='/signup' Component={Signup} />
                <Route path='/loan-application' Component={LoanApplication} />
                <Route path='/unsubscribe/:userId' Component={Unsubscribe} />                
            </Routes>
        </Layout>
    );
};