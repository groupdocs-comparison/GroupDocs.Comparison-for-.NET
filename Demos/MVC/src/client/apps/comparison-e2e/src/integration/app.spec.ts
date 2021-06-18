import { getGreeting } from '../support/app.po';

describe('comparison', () => {
  beforeEach(() => cy.visit('/'));

  it('should display welcome message', () => {
    getGreeting().contains('Welcome to comparison!');
  });
});
