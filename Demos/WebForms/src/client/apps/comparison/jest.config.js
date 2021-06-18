module.exports = {
  name: 'comparison',
  preset: '../../jest.config.js',
  coverageDirectory: '../../coverage/apps/comparison',
  snapshotSerializers: [
    'jest-preset-angular/AngularSnapshotSerializer.js',
    'jest-preset-angular/HTMLCommentSerializer.js'
  ]
};
