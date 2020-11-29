import axios from 'axios';
import { 
	PAGE_DOMAIN,
	PAGE_REGISTER,
	PAGE_SIGN_IN, 
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
		const phone = elements.phone.value || '';
		const firstName = elements.first_name.value || '';
		const secondName = elements.second_name.value || '';
		const password = elements.password.value;
		const passwordConfirm = elements.password_confirm.value;
	
		if (email 
			&& password
			&& passwordConfirm
			&& password === passwordConfirm) {
			
			try {
				await axios.post(PAGE_DOMAIN + PAGE_REGISTER, {
					register_service_id: 0,
					email,
					phone,
					first_name: firstName,
					second_name: secondName,
					password,
					password_confirm: passwordConfirm,
				});

				window.location.href = PAGE_SIGN_IN;
			}
			catch (err) {
				setState(false);
				alert('Ошибка: '+ err.message);
			}
		}
		else if (password !== passwordConfirm) {
			setState(false);
			alert('Поля паролей не совпадают');
		}
		else {
			setState(false);
			alert('Все поля должны быть заполнены');
		}
	}, 0);
};

export default onSubmit;
