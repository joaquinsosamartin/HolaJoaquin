import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

export class ProductFormGroup extends FormGroup {
    constructor(fb: FormBuilder) {
        const controls = {
            // cicles: new FormControl('', []),
            // curse: new FormControl('', [Validators.required]),
            // letter: new FormControl('', [Validators.required]),
            // anyos: new FormControl('', [])
        };

        super(controls);
        fb.group({});
    }
}
