let curso = function (data, model) {
    let self = this;
    self.id = ko.observable(data.id);
    self.nome = ko.observable(data.nome);
    self.processando = ko.observable(false);
    self.nomeOriginal = data.nome;
    self.model = model;

    self.modificado = ko.computed(() => self.nome() !== self.nomeOriginal, this);
    self.undoChanges = () => self.nome(self.nomeOriginal);
    self.save = () => {
        self.processando(true);
        $.ajax({
            url: 'http://backend:5000/api/curso/' + self.id(),
            method: 'PUT',
            contentType: 'application/json; charset=UTF-8',
            data: JSON.stringify(ko.toJS({ nome: self.nome() }))
        })
            .done(() => self.processando(false))
            .fail(() => { self.processando(false); self.nome('error'); });
    }
    self.remove = () => {
        $.ajax({
            url: 'http://backend:5000/api/curso/' + self.id(),
            method: 'DELETE'
        })
            .done(() => model.remove(self))
            .fail(() => { self.processando(false); self.nome('error'); });
    }
}

let model = function () {
    let self = this;
    self.courses = ko.observableArray();

    self.getCourses = () => {
        self.courses.removeAll();
        $.get('http://backend:5000/api/curso')
            .done(data => {
                data.forEach(item => {
                    self.courses.push(new curso(item, self));
                });
            });
    }

    self.addCourse = () => self.courses.push(new curso({ id: 0, nome: '' }, self));
}

let viewModel = new model();
ko.applyBindings(viewModel);
viewModel.getCourses();