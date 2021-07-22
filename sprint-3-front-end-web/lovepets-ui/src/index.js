import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';

import { usuarioAutenticado, parseJwt } from './services/auth';

import './index.css';

import App from './pages/home/App';
import Atendimentos from './pages/atendimentos/atendimentos';
import MeusAtendimentos from './pages/atendimentos/meusatendimentos'
import Login from './pages/login/login';
import Clinicas from './pages/clinicas/clinicas';
import NotFound from './pages/notFound/notFound';

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component : Component}) => (
  <Route 
    render = { props => 
      usuarioAutenticado() && parseJwt().role === "1" ?
      <Component {...props} /> :
      <Redirect to="/login" />
    }
  />
)

const PermissaoLogado = ({ component : Component }) => (
  <Route 
    render = { props =>
      usuarioAutenticado() && (parseJwt().role === "2" || parseJwt().role === "3") ?
      <Component {...props} /> :
      <Redirect to="/login" />
    }
  />
)

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={App} />
        <PermissaoAdm path="/atendimentos" component={Atendimentos} />
        <PermissaoLogado path="/meusatendimentos" component={MeusAtendimentos} />
        <Route path="/login" component={Login} />
        <Route path="/clinicas" component={Clinicas} />
        <Route exact path="/notfound" component={NotFound} />
        <Redirect to="/notFound" />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
