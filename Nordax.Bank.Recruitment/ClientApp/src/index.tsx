import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import { App } from './App';
import { unregister } from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');

const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement);

root.render(
    <BrowserRouter basename={baseUrl==null ? undefined : baseUrl}>
        <App />
    </BrowserRouter>
);

unregister();

