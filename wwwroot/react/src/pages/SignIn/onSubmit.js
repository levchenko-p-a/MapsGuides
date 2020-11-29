import axios from 'axios';
import { 
	PAGE_DOMAIN,
	PAGE_LOGIN,
	PAGE_MAP, 
} from 'consts/page.js';

let timeout;
const onSubmit = (e, setState) => {
	e.preventDefault();

	const target = e.currentTarget;

	setState(true);
	clearTimeout(timeout);
	timeout = setTimeout(async () => {
		const elements = target.elements;
		const email = elements.email.value;
		const password = elements.password.value;
	
		if (email && password) {
			try {
				await axios.post(PAGE_DOMAIN + PAGE_LOGIN, {
					register_service_id: 0,
					email,
					password,
				});

				window.location.href = PAGE_MAP;
			}
			catch (err) {
				setState(false);
				alert('Ошибка: '+ err.message);
			}
		}
		else {
			setState(false);
			alert('Все поля должны быть заполнены');
		}
	}, 0);
};

export default onSubmit;
