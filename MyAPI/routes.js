const ContactList = require('./Model/ContactList');

app.post('/add-contact', async (request, response) => {
  const contactList = new ContactList(request.body);
  try {
    await contactList.save();
    response.status(201).json({
      status: 'Success',
      data: {
        contactList
      }
    });
  } catch (err) {
    response.status(500).json({
      status: 'Failed',
      message: err
    });
  }
});