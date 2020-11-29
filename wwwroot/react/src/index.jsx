import React from 'react';
import { render } from 'react-dom';
import { ThemeProvider } from 'styled-components';
import { Provider as StoreProvider } from 'components/Store';
import { 
	BrowserRouter,
	Switch,
	Route, 
} from 'react-router-dom';
import PageSignUp from 'pages/SignUp';
import PageSignIn from 'pages/SignIn';
import * as page from 'consts/page.js';
import GlobalStyles from './globalStyles.js';

render(<ThemeProvider theme={{}}>
	<StoreProvider>
		<BrowserRouter>
			<Switch>
				<Route
					exact 
					path={page.PAGE_SIGN_UP}>
					<PageSignUp />
				</Route>
				<Route
					exact 
					path={page.PAGE_SIGN_IN}>
					<PageSignIn />
				</Route>
			</Switch>
		</BrowserRouter>
	</StoreProvider>
	<GlobalStyles />
</ThemeProvider>, document.getElementById('root'));
